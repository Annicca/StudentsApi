const STUDENTS_URL = "http://localhost:5122/students-api";

export async function getStudents() {
  const response = await fetch(STUDENTS_URL);
  if (!response.ok) throw new Error("Не удалось получить список студентов");
  return response.json();
}

export async function createStudent(student) {
  const response = await fetch(STUDENTS_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
  if (!response.ok) throw new Error("Не удалось создать студента");
  return response.json();
}
