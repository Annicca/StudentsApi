import { Link } from "react-router";
import StudentForm from "../components/StudentForm.jsx";

export default function CreateStudentPage() {
    return (
        <section className="student-card create-student-page">
            <Link className="back-link" to="/students">← К списку студентов</Link>
            <h2>Создать студента</h2>
            <StudentForm />
        </section>
    );
}
