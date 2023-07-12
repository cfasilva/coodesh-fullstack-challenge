import { Link } from 'react-router-dom'

interface HeaderProps {
    enableNavigation: boolean
}

export function Header(props: HeaderProps) {
    return (
        <header>
            <h1>Coodesh Fullstack Challenge</h1>

            <nav style={{ display: props.enableNavigation ? 'flex' : 'none' }}>
                <Link to="/">Home</Link>
                <Link to="/transactions">Transactions</Link>
                <Link to="/products">Products</Link>
                <Link to="/sellers">Sellers</Link>
            </nav>
        </header>
    )
}