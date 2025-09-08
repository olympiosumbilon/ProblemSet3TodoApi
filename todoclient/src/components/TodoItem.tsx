import { Task } from "../models/Task";

interface Props {
  task: Task;
  onComplete: (id: number) => void;
  onDelete: (id: number) => void;
}

export default function TodoItem({ task, onComplete, onDelete }: Props) {
  const formatDateTime = (iso?: string) => {
    if (!iso) return "";
    // If no timezone info present, treat as UTC
    const hasTz = /[zZ]|[\+\-]\d{2}:?\d{2}$/.test(iso);
    const normalized = hasTz ? iso : `${iso}Z`;
    const d = new Date(normalized);
    if (isNaN(d.getTime())) return "";
    const parts = new Intl.DateTimeFormat("en-US", {
      timeZone: "Asia/Manila",
      year: "numeric",
      month: "2-digit",
      day: "2-digit",
      hour: "2-digit",
      minute: "2-digit",
      hour12: true,
    }).formatToParts(d);
    const get = (type: string) => parts.find(p => p.type === type)?.value || "";
    const mm = get("month");
    const dd = get("day");
    const yyyy = get("year");
    const hh = get("hour").padStart(2, "0");
    const min = get("minute");
    const dayPeriod = (get("dayPeriod") || "").toUpperCase();
    return `${mm}/${dd}/${yyyy} ${hh}:${min} ${dayPeriod}`.trim();
  };
  return (
    <li className="item">
      <div>
        <div className="item-title" style={{ textDecoration: task.isCompleted ? "line-through" : "none" }}>
          {task.title}
        </div>
        <div className="item-meta">
          {task.deadline && <span className="muted">Due: {formatDateTime(task.deadline)}</span>} {" "}
          {task.isCompleted && (
            <span className="badge">Completed {formatDateTime(task.completedAt)}</span>
          )}
        </div>
      </div>
      <div className="item-actions">
        {task.isCompleted ? (
          <>
            <span className="muted">Done</span>
            <button className="btn danger remove-btn" onClick={() => onDelete(task.id)}>Remove</button>
          </>
        ) : (
          <button className="btn success" onClick={() => onComplete(task.id)}>Mark Done</button>
        )}
      </div>
    </li>
  );
}
