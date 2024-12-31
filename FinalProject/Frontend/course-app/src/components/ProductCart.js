import React from 'react'
// import {useCart} from '../context/CartContext'
import { Link } from 'react-router-dom';

export default function ProductCart({course}) {

  // const {addToCart} = useCart();

  const truncateTitle = (title) => {
    if (title.length > 50) {
      return `${title.slice(0, 50)}...`;
    }
    return title;
  };

  return(
    <div className='col-md-4 mb-4'>
      <div className='card h-100 shadow-sm'>
        <Link to={`/product/${course.id}`} style={{textDecoration: "none"}}>
          <img
          src={course.imageUrl}
          alt={course.name}
          className='card-img-top'
          style={{objectFit: "contain", height: "200px"}}
          ></img>
          <div className='card-body'>
            <p className='card-title'>{course.name}</p>
            <p className="card-text">{truncateTitle(course.title)}</p>
            <p className='card-text'>{course.price}₺</p>
          </div>
        </Link>
        <Link to={`/product/${course.id}`}>
    <button className='btn btn-warning w-100 h-100'>
      Go to details
    </button>
  </Link>
      </div>
    </div>
  );
}
