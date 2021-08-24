import React, { useMemo, useState, useEffect } from "react";
import PostTable from "../PostTable/post-table"
import api from "../../api";
import dateFormat from "dateformat";

const DateFormater = ({ value }) => {
    const year = dateFormat(value, "yyyy");
    return (
        <>
            {year === dateFormat(new Date(), "yyyy") ? dateFormat(value, "mm-dd") : dateFormat(value, "yyyy-mm-dd")}
        </>
    );
};

const NumberFormatter = ({ value }) => {
    const inMillions = value >= 1000000
    const inThousands = !inMillions && value >= 1000;
    return (
        <>
            {inMillions ? Math.sign(value) * ((Math.abs(value) / 1000000).toFixed(1)) + 'M' : ''}
            {inThousands ? Math.sign(value) * ((Math.abs(value) / 1000).toFixed(1)) + 'K' : value}
        </>
    );
};

const TextShortFormatter = ({ value }) => {
    return (
        <>
            {value !== null && value.length > 50 ? value.substr(0, 50) + '...' : value}
        </>
    );
};


export default function PostList() {
    const columns = useMemo(
        () => [
            {
                Header: "Post",
                columns: [
                    {
                        Header: "Title",
                        accessor: "title",
                        Cell: ({ cell: { value } }) => <TextShortFormatter value={value} />
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
                        accessor: "ownerUserName",
                        Cell: ({ cell: { value } }) => <TextShortFormatter value={value} />
                    },
                    {
                        Header: "Score",
                        accessor: "score",
                    },
                    {
                        Header: "Answers",
                        accessor: "answerCount",
                        Cell: ({ cell: { value } }) => <NumberFormatter value={value} />
                    },
                    {
                        Header: "Comments",
                        accessor: "commentCount",
                        Cell: ({ cell: { value } }) => <NumberFormatter value={value} />
                    },
                    {
                        Header: "Views",
                        accessor: "viewCount",
                        Cell: ({ cell: { value } }) => <NumberFormatter value={value} />
                    },
                    {
                        Header: "Created",
                        accessor: "creationDate",
                        Cell: ({ cell: { value } }) => <DateFormater value={value} />
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