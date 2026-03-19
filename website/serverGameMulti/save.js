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

io.on("connection", (socket) => {
  console.log(`Player connected: ${socket.id}`);

  socket.on("player_move", (data) => {
    console.log(`Player moved: ${socket.id}`, data);

    //  Envoie x et y séparément
    const { x, y, orientation } = JSON.parse(data); 
    io.emit("player_moved", { id: socket.id, x, y, orientation });  
  });

  socket.on("player_attack", (data) => {
    console.log(`Player attacked: ${socket.id}`, data);

    const { message, damage } = JSON.parse(data); 
    io.emit("player_attack", { id: socket.id, message, damage });
  });

  socket.on("disconnect", () => {
    console.log(`Player disconnected: ${socket.id}`);
    io.emit("player_disconnected", { id: socket.id });
  });
});

server.listen(PORT, () => {
  console.log(`Socket.IO server running on port : ${PORT}`);
});
