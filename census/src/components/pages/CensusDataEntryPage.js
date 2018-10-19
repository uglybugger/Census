import React, { Component } from 'react';
import PropTypes from 'prop-types';

import CensusForm from '../organisms/CensusForm'

import ApiClient from '../../infrastructure/api/ApiClient';
import SubmitCensusCommand from '../../services/SubmitCensusCommand'

class CensusDataEntryPage extends Component {

    constructor(props) {
        super(props);

        this.submit = this.submit.bind(this);
        this.apiClient = new ApiClient();
    }

    async submit(census) {
        var command = new SubmitCensusCommand(census);
        await this.apiClient.send(command);
        setTimeout(() => this.props.history.push("/submitted"), 0);
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