import uuid from "uuid";
import axios from "axios";

class ApiClient {
    constructor(configuration) {
        this.configuration = configuration;

        this.send = this.send.bind(this);
    }

    async send(dto) {
        const baseUrl = this.configuration.Api.Endpoint;

        var request = {
            method: "post",
            baseURL: baseUrl,
            url: dto.route,
            headers: {
                requestId: uuid()
            },
            data: dto
        };
        var response = await axios(request);
        return response;
    }
}

export default ApiClient;