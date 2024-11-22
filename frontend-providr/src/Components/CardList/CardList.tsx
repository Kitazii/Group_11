import React from 'react'
import Card from '../Card/Card';
import "./CardList.css";

interface Props {}

const CardList : React.FC<Props> = (props: Props): JSX.Element => {
  return <div>:
    <Card businessName='Wallace Plumbing' businessCity="Glasgow"/>
    <Card businessName='Conway Scaffolding' businessCity="Saltcoats"/>
    <Card businessName='Skip Hire 101' businessCity="Edinburgh"/>
    </div>
};

export default CardList;