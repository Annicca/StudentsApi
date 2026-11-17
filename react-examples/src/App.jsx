import { BrowserRouter, Route, Routes } from 'react-router';
import RouterLayout from './components/RouterLayout.jsx';
import HomePage from './pages/HomePage.jsx';
import AboutPage from './pages/AboutPage.jsx';
import RouterNotFoundPage from './pages/RouterNotFoundPage.jsx';
import { StudentsPage } from './pages/StudentsPage.jsx';
import CreateStudentPage from './pages/CreateStudentPage.jsx';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<RouterLayout />}>
          <Route index element={<HomePage />} />
          <Route path="students" element={<StudentsPage />} />
          <Route path="create-students" element={<CreateStudentPage />} />
          <Route path="about" element={<AboutPage />} />
          <Route path="*" element={<RouterNotFoundPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
