import { Link } from 'react-router';

export default function RouterNotFoundPage() {
  return (
    <section className="router-page">
      <h2>Страница не найдена</h2>
      <p>Ни один дочерний маршрут не соответствует текущему адресу.</p>
      <Link to="/">На главную магазина</Link>
    </section>
  );
}
