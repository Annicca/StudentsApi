import { NavLink, Outlet } from 'react-router';

export default function RouterLayout() {
  return (
    <div className="router-demo">
      <header className="router-header">
        <nav className="router-nav" aria-label="Навигация магазина">
          <NavLink to="/" end>Главная</NavLink>
          <NavLink to="/students">Студенты</NavLink>
           <NavLink to="/create-students" end>Новый студент</NavLink>
          <NavLink to="/about">О нас</NavLink>
        </nav>
      </header>
      <main className="router-content">
        <Outlet />
      </main>
    </div>
  );
}
