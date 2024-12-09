<<<<<<< HEAD
import { ChangeEvent, SyntheticEvent, useState } from 'react';
=======
import './App.css';

function App() {
 return <>
 <NavBar />
 <Outlet />
 </>;

import React from 'react';
import logo from './logo.svg';
>>>>>>> d13ec04fc8fd47855c3d9d255bc2101e31ad7e10
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
    </div>
  );
}

export default App;
