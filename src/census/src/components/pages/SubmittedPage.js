import React from 'react';
import Page from './Page';

class SubmittedPage extends Page {

    render() {
        return (
            <div>
                <h1>Thank you.</h1>
                <p>Your census has been lodged.</p>
                <p>Why not celebrate with a nice, cold home-brew?</p>
            </div>
        );
    }
}

SubmittedPage.propTypes = {
};

export default SubmittedPage;