import React from 'react';
import ReactDOM from 'react-dom';
import { spy } from 'mobx';
import { Provider } from 'mobx-react';
import ApiClient from './infrastructure/api/ApiClient';
import LogBootstrapper from './infrastructure/logging/LogBootstrapper';
import App from './App';
import './index.css';

import configuration from './config.json';

var logBootstrapper = new LogBootstrapper(configuration);
logBootstrapper.bootstrap();
var apiClient = new ApiClient(configuration);

var stores = {
    apiClient: apiClient,
};

spy((event) => {
    if (event.type === 'action') {
        console.debug("MobX '{ActionName}' with args: {@EventArguments}", event.name, event.arguments);
    }
});

var rootElement = document.getElementById('root');
ReactDOM.render(
    <Provider {...stores}>
        <App />
    </Provider>
    , rootElement);
