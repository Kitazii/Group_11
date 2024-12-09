import React from "react";
import Table from "../../Table/Table";
import RatioList from "../../RatioList/RatioList";

type Props = {};

const DesignPage = (props: Props) => {
    return (
        <>
            <h1>Design Page</h1>
            <RatioList />
            <h2>This is a design page</h2>
            <Table />
        </>
    );
};

export default DesignPage;