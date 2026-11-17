import StaticProductCard from '.../examples/StaticProductCard.jsx';
import PropsExample from '.../examples/PropsExample.jsx';
import JsxExample from '.../examples/JsxExample.jsx';
import ExpressionsExample from '.../examples/ExpressionsExample.jsx';
import ClickExample from '.../examples/ClickExample.jsx';
import VariableCounter from '.../examples/VariableCounter.jsx';
import StateValue from '.../examples/StateValue.jsx';
import CartCounter from '.../examples/CartCounter.jsx';
import SnapshotCounter from '.../examples/SnapshotCounter.jsx';
import BatchCounter from '.../examples/BatchCounter.jsx';
import FunctionalCounter from '.../examples/FunctionalCounter.jsx';
import ObjectCounter from '.../examples/ObjectCounter.jsx';
import ProductList from '.../examples/ProductList.jsx';
import LifecycleExample from '.../examples/LifecycleExample.jsx';
import ApiProductList from '.../examples/ApiProductList.jsx';
import {Card} from ".../Card.jsx";
import { Link } from 'react-router';

const examples = [
  { componentName: StaticProductCard, title: "Компонент и повторное использование", slides: "9\u201310", note: "", lesson: 1 },
  { componentName: PropsExample, title: "Передача props", slides: "11\u201313", note: "", lesson: 1 },
  { componentName: JsxExample, title: "JSX: обёртка, фрагмент, теги и className", slides: "17\u201319", note: "Для запуска добавлена картинка image.svg. Фрагмент не создаёт дополнительный DOM-элемент.", lesson: 1 },
  { componentName: ExpressionsExample, title: "Выражения внутри JSX", slides: "20", note: "", lesson: 1 },
  { componentName: ClickExample, title: "Обработчик события", slides: "4", note: "Откройте консоль браузера: нажатие выводит сообщение.", lesson: 2 },
  { componentName: VariableCounter, title: "Обычная переменная", slides: "5", note: "Надпись намеренно остаётся равной 0. Пример показывает ограничение обычной переменной.", lesson: 2 },
  { componentName: StateValue, title: "Начальное состояние", slides: "8", note: "Setter здесь ещё не используется — как на слайде.", lesson: 2 },
  { componentName: CartCounter, title: "Счётчик с useState", slides: "9", note: "Последовательные нажатия показывают 1, 2, 3.", lesson: 2 },
  { componentName: SnapshotCounter, title: "Состояние текущего рендера", slides: "10", note: "При первом нажатии консоль показывает 0, кнопка — 1.", lesson: 2 },
  { componentName: BatchCounter, title: "Два обновления значением", slides: "11", note: "Одно нажатие увеличивает значение на 1.", lesson: 2 },
  { componentName: FunctionalCounter, title: "Два обновления функцией", slides: "12", note: "Одно нажатие увеличивает значение на 2.", lesson: 2 },
  { componentName: ObjectCounter, title: "Обновление объекта", slides: "13", note: "Название сохраняется, количество увеличивается.", lesson: 2 },
  { componentName: ProductList, title: "Список и key", slides: "14", note: "", lesson: 2 },
  { componentName: LifecycleExample, title: "Монтирование и размонтирование", slides: "15", note: "Увеличьте счётчик. Скройте и покажите его: состояние начнётся с 0.", lesson: 2 },
  { componentName: ApiProductList, title: "Пример работы useEffect", slides: "17", note: "Во вкладке Network виден GET /api/products. Обработка ошибок намеренно оставлена за рамками примера со слайда.", lesson: 2 }
];

export default function ExamplesPage() {
  return(
    <main>
      <header>
        <p>УЧЕБНЫЕ ПРИМЕРЫ · REACT + JAVASCRIPT</p>
        <h1>От компонентов к состоянию</h1>
        <p>Примеры из двух презентаций. Каждый пример находится в отдельном файле src/examples.</p>
        <Link className="router-demo-link" to="/router">Открыть примеры React Router</Link>
      </header>

      {[1, 2].map(lesson =>
        <section key={lesson}>
          <h2>{lesson === 1 ? '1. Введение в React' : '2. Хуки, состояние и эффекты'}</h2>
          <div className="examples">
            {examples.filter(item => item.lesson === lesson).map(({ componentName, title, slides, note }) =>
              <Card
                componentName={componentName}
                title={title}
                slides={slides}
                note={note}
              />
          )}
          </div>
        </section>
      )}
    </main>
  );
}
