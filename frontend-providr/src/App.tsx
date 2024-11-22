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
    </div>
  );
}

export default App;
