export interface Task {
  id: number;
  title: string;
  deadline?: string;
  isCompleted: boolean;
  completedAt?: string;
  createdAt: string;
  updateAt: string;
}