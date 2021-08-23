import api from "../api";

export default class PostService {
    getPage() {
        api.get("Post?PageNumber=1&PageSize=10")
            .then(function (response) {
                console.log(response);
                return response;
            });
    }

}