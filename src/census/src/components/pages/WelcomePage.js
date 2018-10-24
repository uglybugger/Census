import React from 'react';
import {Button} from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Page from './Page';

class WelcomePage extends Page {
    render() {
        return (
            <div>
                <p>
                    Welcome!
                </p>
                <p>
                    <Link to="data-entry"><Button bsStyle="primary">I'm ready to fulfil my civic duty and complete my census.</Button></Link>
                </p>
            </div>
        );
    }
}

WelcomePage.propTypes = {
};

export default WelcomePage;