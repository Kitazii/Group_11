<<<<<<< HEAD
import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import { Search } from './Components/Search/Search';
import { BusinessSearch } from './business';

function App() {

  const [search, setSearch] = useState<string>("");
  //const [searchResult, setSearchResult] = useState<BusinessSearch[]>([]);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
        console.log(e);
    }

    const onClick = (e: SyntheticEvent) => {
        //const result = await searchBusinesses(search);
    };
    
  return (
    <div className="app">
      <Search onClick={onClick} search={search} handleChange={handleChange}/>
      <CardList />
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
