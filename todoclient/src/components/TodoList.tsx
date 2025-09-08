import { useEffect, useState } from "react";
import api from "../services/api";
import { Task } from "../models/Task";
import TodoForm from "./TodoForm";
import TodoItem from "./TodoItem";

export default function TodoList() {
  const [tasks, setTasks] = useState<Task[]>([]);

  const fetchTasks = async () => {
    const res = await api.get<Task[]>("/TaskTodo");
    setTasks(res.data);
  };

  const handleComplete = async (id: number) => {
    await api.put(`/TaskTodo/${id}/complete`);
    fetchTasks();
  };

	const handleDelete = async (id: number) => {
		await api.delete(`/TaskTodo/${id}`);
		fetchTasks();
	};

  useEffect(() => {
    fetchTasks();
  }, []);

  return (
    <div className="paper" style={{ padding: 24 }}>
      <h1 className="page-title">Your Tasks</h1>
      <p className="page-subtitle">Plan, track, and complete your todos.</p>
      <TodoForm onTaskAdded={fetchTasks} />
      <ul className="list">
        {tasks.map((task) => (
          <TodoItem key={task.id} task={task} onComplete={handleComplete} onDelete={handleDelete} />
        ))}
      </ul>
    </div>
  );
}
