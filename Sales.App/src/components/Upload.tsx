import React from 'react'
import { useNavigate } from 'react-router-dom'

import './Upload.css'

export function Upload() {
    const [file, setFile] = React.useState<File>()
    const navigate = useNavigate()

    function submitFile(event: React.FormEvent) {
        event.preventDefault()

        if (!file) {
            return
        }

        const formData = new FormData()
        formData.append('file', file)

        fetch('http://localhost:5247/api/transactions/upload', {
            method: 'POST',
            body: formData
        }).then(() => {
            navigate('/transactions')
        })
    }

    return (
        <div className="container">
            <form onSubmit={submitFile}>
                <input type="file" accept='.txt' onChange={e => setFile(e.target.files![0])} />
                <button type="submit">Upload</button>
            </form>
        </div>
    )
}