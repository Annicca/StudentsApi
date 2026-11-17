import { useState } from "react";
import { Link } from "react-router";
import { createStudent } from "../api/students.js";

const initialForm = { name: "", age: "", group: "" };

export default function StudentForm() {
    const [form, setForm] = useState(initialForm);
    const [submitting, setSubmitting] = useState(false);
    const [error, setError] = useState("");
    const [success, setSuccess] = useState(false);

    function handleChange(event) {
        const { name, value } = event.target;
        setForm(current => ({ ...current, [name]: value }));
    }

    async function handleSubmit(event) {
        event.preventDefault();
        setError("");
        setSuccess(false);

        const name = form.name.trim();
        const group = form.group.trim();
        const age = Number(form.age);

        if (!name || !group || form.age === "" || !Number.isInteger(age) || age < 0) {
            setError("Заполните все поля. Возраст должен быть целым неотрицательным числом.");
            return;
        }

        setSubmitting(true);
        try {
            await createStudent({ name, age, group });
            setForm(initialForm);
            setSuccess(true);
        } catch (requestError) {
            setError(requestError.message);
        } finally {
            setSubmitting(false);
        }
    }

    return (
        <form className="student-form" onSubmit={handleSubmit}>
            <label>Имя<input name="name" value={form.name} onChange={handleChange} placeholder="Иван Иванов" required /></label>
            <label>Возраст<input name="age" type="number" min="0" step="1" value={form.age} onChange={handleChange} placeholder="18" required /></label>
            <label>Группа<input name="group" value={form.group} onChange={handleChange} placeholder="ИС-21" required /></label>
            <button type="submit" disabled={submitting}>{submitting ? "Создание…" : "Создать студента"}</button>
            {error && <p className="form-message form-error" role="alert">{error}</p>}
            {success && (
                <p className="form-message form-success" role="status">
                    Студент успешно создан. <Link to="/students">Открыть список</Link>
                </p>
            )}
        </form>
    );
}
