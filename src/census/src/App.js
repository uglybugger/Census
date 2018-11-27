import React, { Component } from 'react';
import './App.css';
import version from './version.json';
import { Navbar, Nav, NavItem } from 'react-bootstrap';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

import WelcomePage from './components/pages/WelcomePage';
import CensusDataEntryPage from './components/pages/CensusDataEntryPage';
import SubmittedPage from './components/pages/SubmittedPage';
import AboutPage from './components/pages/AboutPage';

class App extends Component {

    render() {
        return (
            <Router>
                <div>
                    <Navbar inverse collapseOnSelect>
                        <Navbar.Header>
                            <Navbar.Brand>
                                <Link to="/">Hipster Census</Link>
                            </Navbar.Brand>
                            <Navbar.Toggle />
                        </Navbar.Header>
                        <Navbar.Collapse>
                            <Nav>
                                <NavItem eventKey={1}>
                                    <Link to="/about">About</Link>
                                </NavItem>
                            </Nav>
                        </Navbar.Collapse>
                    </Navbar>
                    <div className="page-component">
                        <Route exact path="/" component={WelcomePage} />
                        <Route exact path="/data-entry" component={CensusDataEntryPage} />
                        <Route exact path="/submitted" component={SubmittedPage} />
                        <Route exact path="/about" component={AboutPage} />
                    </div>

                    <div className="footer">
                        <hr style={{ "width": "50%" }} />
                        {version.Version}
                    </div>
                </div>
            </Router>
        );
    }
}

App.propTypes = {
};

export default App;
