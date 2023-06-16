export const useXML2JSON = async(xml, tagName) => {
    const parser = new DOMParser();
    const xmlDOM = parser.parseFromString(xml, 'application/xml');
 
    const data = xmlDOM.getElementsByTagName(tagName)[0].childNodes[0].nodeValue;
 
    return JSON.parse(data || '');
}