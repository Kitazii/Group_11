import React from 'react'
import Card from '../Card/Card';
import "./CardList.css";

interface Props {
  searchResults: CompanySearch[];
}
const CardList : React.FC<Props> = ({ searchResults }:Props): JSX.Element => {
  return <>
  {searchResults.length > 0 ? (
    searchResults.map((result) => {
      return <Card id={result.symbol} key={} />;
    })
  ): (
    <h1>No results</h1>
  )}</>;
  
};

export default CardList;