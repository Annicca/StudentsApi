import { getStudents } from "../api/students.js";

export default function CheckStudents() {
  async function handleClick() {
    try {
      const students = await getStudents();
      console.log(students);
    } catch (error) {
      console.log("Не удалось получить список");
      console.error(error);
    } finally {
      console.log("Получение списка завершено");
    }
  }

  return (
    <button onClick={handleClick}>
      Получить студентов
    </button>
  );
}
