import { useState } from "react";
import api from "../services/api";

interface Props {
  onTaskAdded: () => void;
}

export default function TodoForm({ onTaskAdded }: Props) {
  const [title, setTitle] = useState("");
  const [deadline, setDeadline] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!title) return;

    await api.post("/TaskTodo", {
      title,
      deadline: deadline ? new Date(deadline).toISOString() : null,
      isCompleted: false,
      createdAt: new Date().toISOString(),
      updateAt: new Date().toISOString(),
    });

    setTitle("");
    setDeadline("");
    onTaskAdded();
  };

  return (
    <form onSubmit={handleSubmit} className="form" style={{ marginTop: 12 }}>
      <input
        type="text"
        placeholder="Enter task..."
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        className="input"
      />
      <input
        type="date"
        value={deadline}
        onChange={(e) => setDeadline(e.target.value)}
        className="date-input"
      />
      <button type="submit" className="btn">Add</button>
    </form>
  );
}
