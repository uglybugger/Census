import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

import LogBootstrapper from './infrastructure/logging/LogBootstrapper';

var logBootstrapper = new LogBootstrapper();
logBootstrapper.bootstrap();

var rootElement = document.getElementById('root');
ReactDOM.render(<App />, rootElement);

console.info("Application online");
