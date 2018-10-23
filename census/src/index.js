import React from 'react';
import ReactDOM from 'react-dom';
import { spy } from 'mobx';
import { Provider } from 'mobx-react';
import ApiClient from './infrastructure/api/ApiClient';
import LogBootstrapper from './infrastructure/logging/LogBootstrapper';
import App from './App';
import './index.css';

var logBootstrapper = new LogBootstrapper();
logBootstrapper.bootstrap();

var apiClient = new ApiClient();

var stores = {
    apiClient: apiClient,
};

spy((event) => {
    if (event.type === 'action') {
        console.debug("{event.name} with args: {event.arguments}");
    }
});

var rootElement = document.getElementById('root');
ReactDOM.render(
    <Provider {...stores}>
        <App />
    </Provider>
    , rootElement);
