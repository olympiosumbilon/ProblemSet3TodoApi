import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:8080/api", // adjust if using docker compose
});

export default api;
