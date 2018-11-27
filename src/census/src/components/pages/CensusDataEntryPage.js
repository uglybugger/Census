import React from 'react';
import PropTypes from 'prop-types';
import { action } from "mobx";
import { observer, inject } from 'mobx-react';
import { compose } from 'recompose';

import Page from './Page';
import CensusForm from '../organisms/CensusForm';
import ApiClient from '../../infrastructure/api/ApiClient';
import SubmitCensusCommand from '../../infrastructure/api/SubmitCensusCommand';
import { Logger } from 'structured-log';
import CompletedCensusDto from '../../infrastructure/api/CompletedCensusDto';

class CensusDataEntryPage extends Page {

    constructor(props) {
        super(props);

        this.submit = action(this.submit.bind(this));
    }

    async submit(census) {
        var completedCensusDto = new CompletedCensusDto(census.id, census.accessToken, census.legalName, census.baristaName, census.beardLength, census.gearInches, census.beerBitterness, census.favouriteBand);
        var command = new SubmitCensusCommand(completedCensusDto);
        await this.props.apiClient.send(command);
        setTimeout(() => this.props.history.push("/submitted"), 0);
    }

    render() {
        return (
            <CensusForm
                submit={this.submit}
                logger={this.props.logger}
            />
        );
    }
}

CensusDataEntryPage.propTypes = {
    apiClient: PropTypes.instanceOf(ApiClient).isRequired,
    logger: PropTypes.instanceOf(Logger).isRequired
};

export default compose(inject('apiClient', 'logger'), observer)(CensusDataEntryPage);