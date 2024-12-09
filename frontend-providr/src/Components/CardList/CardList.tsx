import React from 'react'
import Card from '../Card/Card';
import "./CardList.css";

<<<<<<< HEAD
interface Props {}

const CardList : React.FC<Props> = (props: Props): JSX.Element => {
  return <div>:
    <Card businessName='Wallace Plumbing' businessCity="Glasgow"/>
    <Card businessName='Conway Scaffolding' businessCity="Saltcoats"/>
    <Card businessName='Skip Hire 101' businessCity="Edinburgh"/>
    </div>
=======
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
  
>>>>>>> d13ec04fc8fd47855c3d9d255bc2101e31ad7e10
};

export default CardList;