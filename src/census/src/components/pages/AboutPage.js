import React from 'react';
import Page from './Page';

class AboutPage extends Page {

    render() {
        return (
            <div>
                <h1>About</h1>
                <p>
                    Here's how to create an API client and lodge your own census:
                </p>
            </div>
        );
    }
}

AboutPage.propTypes = {
};

export default AboutPage;