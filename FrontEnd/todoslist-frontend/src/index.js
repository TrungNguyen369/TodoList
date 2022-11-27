import React from 'react';
import ReactDOM from 'react-dom/client';
import TodosList from './components/TodosList';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
   <TodosList />
  </React.StrictMode>
);

