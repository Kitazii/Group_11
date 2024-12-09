import React from "react";
import { testIncomeStatementData } from "./testData";
import { Business } from "../../business";

const data = testIncomeStatementData;

type Props = {};

const configs = [
    {
        label: "Email",
        render: (business: Business) => business.businessEmail
    },
    {
        label: "City",
        render: (business: Business) => business.businessCity
    }
]

const Table = (props: Props) => {
    const renderedRows = data.map((business) => {
        return (
            <tr key={business.cik}>
                {configs.map((val:any) => {
                    return (
                    <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                        {val.render(business)}
                    </td>
                    )
                })}
            </tr>
        );
    });
    const renderedHeaders = configs.map((config:any) => {
        return (
            <th className="p-4 text-left text-xs font-medium text-fray-500 uppercase tracking-wider"
            key={config.label}
            >{config.label}</th>
        )
    })
    return <div className= "bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8">
        <table>
            <thead className="min-w-full divide-y divide=gray-200 m-5">{renderedHeaders}</thead>
            <tbody>{renderedRows}</tbody>
        </table>
        </div>;
};

export default Table;