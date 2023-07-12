import { Link } from 'react-router-dom'

export function Header() {
    return (
        <header>
            <h1>Coodesh Fullstack Challenge</h1>
            <nav>
                <Link to="/">Home</Link>
                <Link to="/transactions">Transactions</Link>
                <Link to="/products">Products</Link>
                <Link to="/sellers">Sellers</Link>
            </nav>
        </header>
    )
}