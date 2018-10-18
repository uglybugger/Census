import React, { Component } from 'react';
import PropTypes from 'prop-types';

import CensusForm from '../components/censusForm/CensusForm'

import ApiClient from '../services/ApiClient';
import SubmitCensusCommand from '../services/SubmitCensusCommand'

class CensusDataEntryPage extends Component {

    constructor(props) {
        super(props);

        this.submit = this.submit.bind(this);
        this.apiClient = new ApiClient();
    }

    async submit(census) {
        var command = new SubmitCensusCommand(census);
        await this.apiClient.send(command);
        this.props.history.push("/submitted");
    }

    render() {
        return (
            <CensusForm submit={this.submit} />
        );
    }
}

CensusDataEntryPage.propTypes = {
    history: PropTypes.object.isRequired
};

export default CensusDataEntryPage;