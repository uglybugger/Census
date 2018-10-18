import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import ApiClient from './services/ApiClient';

var apiClient = new ApiClient();

var rootElement = document.getElementById('root');
ReactDOM.render(
    <App
        apiClient={apiClient}
    />
    , rootElement);
