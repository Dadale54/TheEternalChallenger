const PORT = 3000;
const http = require('http');
const express = require('express');
const app = express();
const { Server } = require("socket.io");

const server = http.createServer(app);
const io = new Server(server, {
  cors: {
    origin: "theternalchallenger.fr",
    methods: ["GET", "POST"],
  },
});

// Stockage des paires de joueurs
const playerPairs = {};
let waitingPlayer = null;

io.on("connection", (socket) => {
  console.log(`Player connected: ${socket.id}`);

  if (waitingPlayer) {
    // Associer le joueur en attente avec le nouveau joueur
    playerPairs[socket.id] = waitingPlayer;
    playerPairs[waitingPlayer] = socket.id;
    console.log(`Players paired: ${socket.id} <-> ${waitingPlayer}`);

    // Informer les deux joueurs qu'ils sont connectés
    socket.emit("paired", { partnerId: waitingPlayer });
    io.to(waitingPlayer).emit("paired", { partnerId: socket.id });

    waitingPlayer = null;
  } else {
    // Pas de joueur en attente, mettre ce joueur en file d'attente
    waitingPlayer = socket.id;
  }

  socket.on("player_move", (data) => {
    console.log(`Player moved: ${socket.id}`, data);

    const { x, y, orientation } = JSON.parse(data);
    const partnerId = playerPairs[socket.id];

    if (partnerId) {
      // Envoyer les données au partenaire
      io.to(partnerId).emit("player_moved", { id: socket.id, x, y, orientation });
    }
  });

  socket.on("player_attack", (data) => {
    console.log(`Player attacked: ${socket.id}`, data);

    const { message, damage } = JSON.parse(data);
    const partnerId = playerPairs[socket.id];

    if (partnerId) {
      // Envoyer les données au partenaire
      io.to(partnerId).emit("player_attack", { id: socket.id, message, damage });
    }
  });

  socket.on("disconnect", () => {
    console.log(`Player disconnected: ${socket.id}`);

    const partnerId = playerPairs[socket.id];
    if (partnerId) {
      // Informer le partenaire de la déconnexion
      io.to(partnerId).emit("player_disconnected", { id: socket.id });

      // Retirer la paire
      delete playerPairs[partnerId];
      delete playerPairs[socket.id];
    }

    if (waitingPlayer === socket.id) {
      waitingPlayer = null;
    }
  });
});

server.listen(PORT, () => {
  console.log(`Socket.IO server running on port : ${PORT}`);
});
