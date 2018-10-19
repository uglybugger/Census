import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

import ApiClient from './infrastructure/api/ApiClient';
import LogBootstrapper from './infrastructure/logging/LogBootstrapper';

var apiClient = new ApiClient();
var logBootstrapper = new LogBootstrapper(apiClient);
logBootstrapper.bootstrap();

var rootElement = document.getElementById('root');
ReactDOM.render(<App />, rootElement);

console.info("Application online");
