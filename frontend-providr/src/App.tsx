<<<<<<< HEAD
import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import { Search } from './Components/Search/Search';
import { BusinessSearch } from './business';

function App() {

  const [search, setSearch] = useState<string>("");
  //const [searchResult, setSearchResult] = useState<BusinessSearch[]>([]);

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
    
  return (
    <div className="app">
      <Search onClick={onClick} search={search} handleChange={handleChange}/>
      <ListPortfolio portfolioValues={portfolioValues}/>
      <CardList searchResults = {searhResults} onPortfolioCreate={onPortfolioCreate} />
      {serverError && <div>Unable to connect to API</div>}
      

=======
import React from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
>>>>>>> Kieran
    </div>
  );
}

export default App;
