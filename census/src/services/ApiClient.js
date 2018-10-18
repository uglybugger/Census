import uuid from 'uuid';
import axios from 'axios';

class ApiClient {
    async send(dto) {
        const baseUrl = "http://localhost:61155/";

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