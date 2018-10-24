import { Component } from 'react';
import { PropTypes } from 'prop-types';

class Page extends Component {
    constructor(props) {
        super(props);

        console.debug("Navigated to {Route}", props.history.location.pathname);
    }
}

Page.propTypes = {
    history: PropTypes.object.isRequired,
};

export default Page;
