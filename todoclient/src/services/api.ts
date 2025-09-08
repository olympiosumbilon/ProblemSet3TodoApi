import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7045/api", // adjust if using docker compose
});

export default api;
