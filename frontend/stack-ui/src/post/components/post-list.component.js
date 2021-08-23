import React, { useMemo, useState, useEffect } from "react";
import PostTable from "../PostTable/post-table"
import api from "../../api";

export default function PostList() {
    const columns = useMemo(
        () => [
            {
                Header: "Post",
                columns: [
                    {
                        Header: "Title",
                        accessor: "title"
                    },
                    {
                        Header: "Type",
                        accessor: "postType"
                    }
                ]
            },
            {
                Header: "Details",
                columns: [
                    {
                        Header: "User",
                        accessor: "ownerUserName"
                    },
                    {
                        Header: "Score",
                        accessor: "score",
                    },
                    {
                        Header: "Answers",
                        accessor: "answerCount",
                    },
                    {
                        Header: "Comments",
                        accessor: "commentCount"
                    },
                    {
                        Header: "Views",
                        accessor: "viewCount"
                    },
                    {
                        Header: "Created",
                        accessor: "creationDate"
                    }
                ]
            }
        ],
        []
    );

    const [data, setData] = useState([]);

    useEffect(() => {
        (async () => {
            const response = await api.get("Post?PageNumber=1&PageSize=10");
            var succeeded = response.data.succeeded;
            if (succeeded)
                setData(response.data.data);
            else
                console.error(response.errors);


        })();
    }, []);

    return (
        <div>
            <PostTable columns={columns} data={data} />
        </div>
    );


}