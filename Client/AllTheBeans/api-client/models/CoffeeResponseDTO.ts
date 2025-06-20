/* tslint:disable */
/* eslint-disable */
/**
 * AllTheBeans-API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CoffeeResponseDTO
 */
export interface CoffeeResponseDTO {
    /**
     * 
     * @type {number}
     * @memberof CoffeeResponseDTO
     */
    id?: number;
    /**
     * 
     * @type {string}
     * @memberof CoffeeResponseDTO
     */
    name?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CoffeeResponseDTO
     */
    description?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CoffeeResponseDTO
     */
    country?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CoffeeResponseDTO
     */
    image?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CoffeeResponseDTO
     */
    cost?: number;
    /**
     * 
     * @type {string}
     * @memberof CoffeeResponseDTO
     */
    colour?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof CoffeeResponseDTO
     */
    isBeanOfTheDay?: boolean;
}

/**
 * Check if a given object implements the CoffeeResponseDTO interface.
 */
export function instanceOfCoffeeResponseDTO(value: object): value is CoffeeResponseDTO {
    return true;
}

export function CoffeeResponseDTOFromJSON(json: any): CoffeeResponseDTO {
    return CoffeeResponseDTOFromJSONTyped(json, false);
}

export function CoffeeResponseDTOFromJSONTyped(json: any, ignoreDiscriminator: boolean): CoffeeResponseDTO {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'name': json['name'] == null ? undefined : json['name'],
        'description': json['description'] == null ? undefined : json['description'],
        'country': json['country'] == null ? undefined : json['country'],
        'image': json['image'] == null ? undefined : json['image'],
        'cost': json['cost'] == null ? undefined : json['cost'],
        'colour': json['colour'] == null ? undefined : json['colour'],
        'isBeanOfTheDay': json['isBeanOfTheDay'] == null ? undefined : json['isBeanOfTheDay'],
    };
}

export function CoffeeResponseDTOToJSON(json: any): CoffeeResponseDTO {
    return CoffeeResponseDTOToJSONTyped(json, false);
}

export function CoffeeResponseDTOToJSONTyped(value?: CoffeeResponseDTO | null, ignoreDiscriminator: boolean = false): any {
    if (value == null) {
        return value;
    }

    return {
        
        'id': value['id'],
        'name': value['name'],
        'description': value['description'],
        'country': value['country'],
        'image': value['image'],
        'cost': value['cost'],
        'colour': value['colour'],
        'isBeanOfTheDay': value['isBeanOfTheDay'],
    };
}

