import React, { ChangeEvent, SyntheticEvent } from 'react';

interface Props {
  onClick: (e: SyntheticEvent) => void;
  search: string;
  handleChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({ onClick, search, handleChange }) => {
  return (
    <div>
      <input value={search} onChange={handleChange} placeholder="Search..." />
      <button onClick={onClick}>Search</button>
    </div>
  );
};

export { Search };

