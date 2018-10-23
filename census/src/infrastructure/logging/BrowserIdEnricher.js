import localStorage from 'mobx-localstorage';
import uuid from 'uuid';

class BrowserIdEnricher {

    constructor() {

        this.browserId = localStorage.getItem('browserId') || uuid();
        localStorage.setItem('browserId', this.browserId);


        this.enrich = this.enrich.bind(this);
    }

    enrich(properties) {
        return {
            BrowserId: this.browserId
        };
    }
}

export default BrowserIdEnricher;
