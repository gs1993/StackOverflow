import http from "../http-common";

const getAll = (params) => {
    return http.get("Post", { params })
        .then(function (response) {
            var data = response.data.data;
            var totalItems = response.data.totalItems;

            return { data, totalItems };
        });
};

const exportedObject = {
    getAll
};

export default exportedObject;