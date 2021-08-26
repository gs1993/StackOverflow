import React, { useMemo, useState, useEffect } from "react";
import PostTable from "../PostTable/post-table";
import PostService from "../post.service";
import dateFormat from "dateformat";
import Pagination from "@material-ui/lab/Pagination";

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

    const pageSizes = [3, 6, 9];

    const [data, setData] = useState([]);
    const [page, setPage] = useState(1);
    const [count, setCount] = useState(0);
    const [pageSize, setPageSize] = useState(3);

    const getRequestParams = (page, pageSize) => {
        let params = {};


        if (page) {
            params["pageIndex"] = page;
        }

        if (pageSize) {
            params["pageSize"] = pageSize;
        }

        return params;
    };

    const retrievePosts = () => {
        const params = getRequestParams(page, pageSize);
        PostService.getAll(params)
            .then((response) => {
                const { data, totalItems } = response;

                const totalPages = Math.ceil(totalItems / pageSize);
                setData(data);
                setCount(totalPages);
            })
            .catch((e) => {
                console.log(e);
            });
    };

    useEffect(retrievePosts, [page, pageSize]);

    const handlePageChange = (event, value) => {
        setPage(value);
    };

    const handlePageSizeChange = (event) => {
        setPageSize(event.target.value);
        setPage(0);
    };

    return (
        <div>
            <div className="col-md-12 list">
                <div className="mt-3">
                    {"Items per Page: "}
                    <select onChange={handlePageSizeChange} value={pageSize}>
                        {pageSizes.map((size) => (
                            <option key={size} value={size}>
                                {size}
                            </option>
                        ))}
                    </select>

                    <Pagination
                        className="my-3"
                        count={count}
                        page={page}
                        siblingCount={1}
                        boundaryCount={1}
                        variant="outlined"
                        shape="rounded"
                        onChange={handlePageChange}
                    />

                </div>
            </div>

            <PostTable columns={columns} data={data} pageSize={pageSize}
                handlePageSizeChange={handlePageSizeChange} />
        </div>
    );
}