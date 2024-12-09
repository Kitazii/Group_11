import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import { BusinessSearch } from "../../../business";

interface Props {}

const SearchPage = (props: Props) => {
    const [search, setSearch] = useState<string>("");
    const [searchResult, setSearchResult] = useState<BusinessSearch[]>([]);

  const [portfolioValues,setPortfolioValues] = useState<string[]>([]);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
        console.log(e);
    }

    const onPortfolioCreate = (e: any) => {
      e.preventDefault();
      const exists = portfolioValues.find((value) => value === e.target[0].value)
      if (exists) return;
      const updatedPortfolio = [...portfolioValues, e.target[0].value]
      setPortfolioValues(updatedPortfolio);
    }

    const onClick = (e: SyntheticEvent) => {
        //const result = await searchBusinesses(search);
    };
    
    return <div className="app">
    <Search onClick={onClick} search={search} handleChange={handleChange}/>
    <ListPortfolio portfolioValues={portfolioValues}/>
    <CardList searchResults = {searhResults} onPortfolioCreate={onPortfolioCreate} />
    {serverError && <div>Unable to connect to API</div>};
    </>
}

export default SearchPage;

function useState<T>(arg0: string): [any, any] {
    throw new Error("Function not implemented.");
}
