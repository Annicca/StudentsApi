import { useEffect, useState } from "react";
import { Link } from "react-router";
import { getStudents } from "../api/students.js";

export const StudentsPage = () => {
    const [students, setStudents] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        async function loadStudents() {
            try {
                setStudents(await getStudents());
            } catch {
                setError("Не удалось загрузить студентов");
            } finally {
                setLoading(false);
            }
        }
        loadStudents();
    }, []);

    return (
        <main className="students-page">
            <section className="student-card">
                <div className="students-heading">
                    <h2>Список студентов</h2>
                    <Link className="create-student-link" to="/create-students">Добавить студента</Link>
                </div>
                {loading && <p>Загрузка студентов…</p>}
                {error && <p className="form-error" role="alert">{error}</p>}
                {!loading && !error && students.length === 0 && <p>Студентов пока нет.</p>}
                {!loading && !error && students.length > 0 && (
                    <ul className="student-list">
                        {students.map((student, index) => (
                            <li key={student.id ?? `${student.name}-${index}`}>
                                <strong>{student.name}</strong>
                                <span>{student.age} лет · {student.group}</span>
                            </li>
                        ))}
                    </ul>
                )}
            </section>
        </main>
    );
};
