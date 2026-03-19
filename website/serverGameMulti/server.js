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

// Stockage des joueurs en attente
const waitingPlayers = []; 

// Initialize playerPairs 
const playerPairs = {}; 

io.on("connection", (socket) => {
  console.log(`Player connected: ${socket.id}`);

  // Ajouter le joueur à la file d'attente
  waitingPlayers.push(socket.id);
  console.log("Waiting players:", waitingPlayers);

  // Vérifier s'il y a au moins deux joueurs en attente
  if (waitingPlayers.length >= 2) {
    // Prendre les deux premiers joueurs de la file d'attente
    const player1 = waitingPlayers.shift();
    const player2 = waitingPlayers.shift();

    // Stocker la paire
    playerPairs[player1] = player2;
    playerPairs[player2] = player1;

    console.log(`Players paired: ${player1} <-> ${player2}`);

    // Informer les deux joueurs qu'ils sont connectés
    io.to(player1).emit("paired", { partnerId: player2 });
    io.to(player2).emit("paired", { partnerId: player1 });
  }

  socket.on("player_move", (data) => {
    // Code pour gérer "player_move" (sans logs)
    const { x, y, orientation } = JSON.parse(data); 
    const partnerId = playerPairs[socket.id];

    if (partnerId) {
      io.to(partnerId).emit("player_moved", { id: socket.id, x, y, orientation });
    }
  });

  socket.on("player_attack", (data) => {
    // Code pour gérer "player_attack" (sans logs)
    const { message, damage } = JSON.parse(data);
    const partnerId = playerPairs[socket.id];

    if (partnerId) {
      io.to(partnerId).emit("player_attack", { id: socket.id, message, damage });
    } 
  });

  socket.on("disconnect", () => {
    console.log(`Player disconnected: ${socket.id}`);

    // Retirer le joueur de la file d'attente s'il y est
    const index = waitingPlayers.indexOf(socket.id);
    if (index > -1) {
      waitingPlayers.splice(index, 1);
    }

    const partnerId = playerPairs[socket.id];
    if (partnerId) {
      io.to(partnerId).emit("player_disconnected", { id: socket.id });

      delete playerPairs[partnerId];
      delete playerPairs[socket.id];
    }
  });
});

server.listen(PORT, () => {
  console.log(`Socket.IO server running on port : ${PORT}`);
});

