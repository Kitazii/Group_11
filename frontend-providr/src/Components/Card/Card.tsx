import React from 'react'
import "./Card.css";

interface Props {
  businessName: string;
  businessCity: String;
}

const Card: React.FC<Props> = ({businessName, businessCity}: Props) : JSX.Element => {
  return (
    <div className="card">
      <img
        src="https://b3503797.smushcdn.com/3503797/wp-content/uploads/2023/01/iStock-1341381755-1024x683.jpg?lossy=2&strip=1&webp=1"
        alt="company-image"/>

    <div className="details">
      <h2>{businessName}</h2>
      <p>{businessCity}</p>
    </div>

    <p className="info">
      Providr Inc {"\u2122"} 
    </p>
    </div>
  )
}

export default Card